using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Net.MimeTypes;
using SoftBreeze.BlueHrm.PersonalInformation;
using SoftBreeze.BlueHrm.Storage;

namespace SoftBreeze.BlueHrm.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : BlueHrmControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly IBinaryObjectManager _binaryObjectManager;

        public ProfileController(UserManager userManager, IBinaryObjectManager binaryObjectManager,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _binaryObjectManager = binaryObjectManager;
            _employeeService = employeeService;
        }

        [DisableAuditing]
        public async Task<FileResult> GetProfilePicture()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            if (user.ProfilePictureId == null)
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(user.ProfilePictureId.Value);
        }

        [DisableAuditing]
        public async Task<FileResult> GetProfilePictureByUserId(long userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            if (user.ProfilePictureId == null)
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(user.ProfilePictureId.Value);
        }

        [DisableAuditing]
        public async Task<FileResult> GetProfilePictureById(string id = "")
        {
            if (id.IsNullOrEmpty())
            {
                return GetDefaultProfilePicture();                
            }

            return await GetProfilePictureById(Guid.Parse(id));
        }

        [UnitOfWork]
        public async virtual Task ChangeProfilePicture(long employeeId = 0)
        {
            if (Request.Files.Count <= 0 || Request.Files[0] == null)
            {
                throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
            }
            
            var file = Request.Files[0];

            if (file.ContentLength > 30720) //30KB.
            {
                throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit"));
            }

            var userId = employeeId == 0 ? AbpSession.GetUserId() : employeeId;
            var user = await _userManager.GetUserByIdAsync(userId);

            //Delete old picture
            if (user.ProfilePictureId.HasValue)
            {
                await _binaryObjectManager.DeleteAsync(user.ProfilePictureId.Value);
            }

            //Save new picture
            var storedFile = new BinaryObject(file.InputStream.GetAllBytes());
            await _binaryObjectManager.SaveAsync(storedFile);

            //Update new picture on the user
            user.ProfilePictureId = storedFile.Id;
            await _userManager.UpdateAsync(user);
        }

        private FileResult GetDefaultProfilePicture()
        {
            return File(Server.MapPath("~/Common/Images/default-profile-picture.png"), MimeTypeNames.ImagePng);
        }

        private async Task<FileResult> GetProfilePictureById(Guid profilePictureId)
        {
            var file = await _binaryObjectManager.GetOrNullAsync(profilePictureId);
            if (file == null)
            {
                return GetDefaultProfilePicture();
            }

            return File(file.Bytes, MimeTypeNames.ImageJpeg);
        }
    }
}