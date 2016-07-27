/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/linq/linq.d.ts" />
'use strict';

namespace controlPC.Core {
    export class Index {
        private _instance: Index;

        constructor() {
        }

        get instance() {
            if (this._instance === null) {
                this._instance = new Index();
            }
            return this._instance;
        }

        public startIndex() {
            this.setEvent();
        }

        private setEvent() {
            $('button').off('click').on('click', this.buttonClick.bind(this));
        }

        private buttonClick(event: Event) {
            var param: Object = {
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
                .done((html: string) => {
                    $('.table').empty();
                    var a: JQuery = $(html).find('.table');
                    $('.table').append(a.children());
                });
        }
    }
}


$(window).on('load', () => {
    var instanse: controlPC.Core.Index = new controlPC.Core.Index();
    instanse.startIndex();
});
