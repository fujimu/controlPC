/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/linq/linq.d.ts" />
'use strict';
var controlPC;
(function (controlPC) {
    var Core;
    (function (Core) {
        var Index = (function () {
            function Index() {
            }
            Object.defineProperty(Index.prototype, "instance", {
                get: function () {
                    if (this._instance === null) {
                        this._instance = new Index();
                    }
                    return this._instance;
                },
                enumerable: true,
                configurable: true
            });
            Index.prototype.startIndex = function () {
                this.setEvent();
            };
            Index.prototype.setEvent = function () {
                $('button').off('click').on('click', this.buttonClick.bind(this));
            };
            Index.prototype.buttonClick = function (event) {
                var param = {
                    id: parseInt($('#id').val(), 10),
                    ipAdress: $('#ipAdress').val(),
                    classification: parseInt($('#classification').val(), 10),
                    type: $('#type').val(),
                    typeNumber: $('#typeNumber').val(),
                    userName: $('#userName').val(),
                    pcName: $('#pcName').val(),
                    memo: $('#memo').val()
                };
                //var param: Object = {
                //    id: 1,
                //    ipAdress: $('#ipAdress').val(),
                //    classification: 1,
                //    type: $('#type').val(),
                //    typeNumber: $('#typeNumber').val(),
                //    userName: $('#userName').val(),
                //    pcName: $('#pcName').val(),
                //    memo: $('#memo').val()
                //};
                $.ajax({
                    type: 'html',
                    url: '/ControlPCs/Index',
                    method: 'POST',
                    data: param
                })
                    .done(function (html) {
                    $('.table').empty();
                    var a = $(html).find('.table');
                    $('.table').append(a.children());
                });
            };
            return Index;
        }());
        Core.Index = Index;
    })(Core = controlPC.Core || (controlPC.Core = {}));
})(controlPC || (controlPC = {}));
$(window).on('load', function () {
    var instanse = new controlPC.Core.Index();
    instanse.startIndex();
});
//# sourceMappingURL=Index.js.map