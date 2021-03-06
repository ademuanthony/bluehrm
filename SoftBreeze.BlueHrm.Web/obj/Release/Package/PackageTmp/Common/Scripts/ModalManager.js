﻿var app = app || {};
(function ($) {

    var _loadedScripts = [];

    app.modals = app.modals || {};

    app.ModalManager = (function () {

        var _normalizeOptions = function (options) {
            if (!options.modalId) {
                options.modalId = 'Modal_' + (Math.floor((Math.random() * 1000000))) + new Date().getTime();
            }
        }

        function _removeContainer(modalId) {
            var _containerId = modalId + 'Container';
            var _containerSelector = '#' + _containerId;

            var $container = $(_containerSelector);
            if ($container.length) {
                $container.remove();
            }
        };

        function _createContainer(modalId) {
            _removeContainer(modalId);

            var _containerId = modalId + 'Container';
            return $('<div id="' + _containerId + '"></div>')
                .append(
                    '<div id="' + modalId + '" class="modal fade" tabindex="-1" role="modal" aria-hidden="true">' +
                    '  <div class="modal-dialog">' +
                    '    <div class="modal-content"></div>' +
                    '  </div>' +
                    '</div>'
                ).appendTo('body');
        }

        return function (options) {

            _normalizeOptions(options);

            var _$modal = null;
            var _modalId = options.modalId;
            var _modalSelector = '#' + _modalId;
            var _modalObject = null;

            var _publicApi = null;
            var _args = null;

            function _saveModal() {
                if (_modalObject && _modalObject.save) {
                    _modalObject.save();
                }
            }

            function _initAndShowModal() {
                _$modal = $(_modalSelector);

                _$modal.modal({
                    backdrop: 'static'
                });

                _$modal.on('hidden.bs.modal', function () {
                    _removeContainer(_modalId);
                });

                _$modal.on('shown.bs.modal', function () {
                    _$modal.find('input:first').focus();
                });

                var modalClass = app.modals[options.modalClass];
                if (modalClass) {
                    _modalObject = new modalClass();
                    if (_modalObject.init) {
                        _modalObject.init(_publicApi, _args);
                    }
                }

                _$modal.find('.save-button').click(function () {
                    _saveModal();
                });

                _$modal.find('.modal-body').keydown(function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                        _saveModal();
                    }
                });

                _$modal.modal('show');
            };

            var _open = function (args) {
                _args = args || {};
                _createContainer(_modalId)
                    .find('.modal-content')
                    .load(options.viewUrl, _args, function (response, status, xhr) {
                        if (status == "error") {
                            abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                            return;
                        };

                        if (options.scriptUrl && _.indexOf(_loadedScripts, options.scriptUrl) < 0) {
                            $.getScript(options.scriptUrl)
                                .done(function (script, textStatus) {
                                    _loadedScripts.push(options.scriptUrl);
                                    _initAndShowModal();
                                })
                                .fail(function (jqxhr, settings, exception) {
                                    abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                                });
                        } else {
                            _initAndShowModal();
                        }
                    });
            };

            var _close = function() {
                if (!_$modal) {
                    return;
                }

                _$modal.modal('hide');
            };

            function _setBusy(isBusy) {
                if (!_$modal) {
                    return;
                }

                _$modal.find('.modal-footer button').buttonBusy(isBusy);
            }

            _publicApi = {

                open: _open,

                reopen: function() {
                    _open(_args);
                },

                close: _close,

                getModalId: function () {
                    return _modalId;
                },

                getModal: function () {
                    return _$modal;
                },

                getArgs: function () {
                    return _args;
                },

                setBusy: _setBusy

            }

            return _publicApi;

        };
    })();

})(jQuery);