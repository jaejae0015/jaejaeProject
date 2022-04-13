//화면단에서 JSON으로 받은 값에 대해서 setValues로 쓸 수 있도록 함수 추가
$.fn.extend({
    // 내부 컨트롤에 정의한 모델의 값을 표시
    setValues: function (sScope) {
        $(this).find("[data-model]").each(function (i, el) {
            var model = $(el).data('model');
            var type = el.type;
            var ctrlId = $(el).attr('id');
            var value = eval(sScope + "." + model);
            if (value === undefined)
                return;

            if (type == "radio" || type == "checkbox") {
                $(el).prop('checked', ($(el).val() == value));
            }
            else if (el.type === undefined) {
                $(el).html(value);
            }
            else {
                try {
                    if (typeof (CKEDITOR) != "undefined" && typeof (CKEDITOR) != undefined && CKEDITOR.instances[ctrlId]) {
                        $(el).text(value);
                        CKEDITOR.instances[ctrlId].setData(value);
                    } else if (type == "textarea") {
                        $(el).text(value);
                    } else {
                        $(el).val(value);
                    }
                } catch (E) { console.log(E); }
            }

        });
    },
    // 내부 컨트롤의 값을 정의한 모델로 가져옴
    getValues: function (sScope) {
        $(this).find("[data-model]").each(function (i, el) {
            var model = $(el).data('model');
            var type = el.type;
            var value = eval(sScope + "." + model);

            if (value === undefined)
                return;

            if (type == "radio") {
                if ($(el).prop('checked'))
                    eval(sScope + "." + model + "=$(el).inputmask('unmaskedvalue')");
            }
            else if (type == "checkbox") {
                if ($(el).prop('checked'))
                    eval(sScope + "." + model + "=$(el).inputmask('unmaskedvalue')");
                else
                    eval(sScope + "." + model + "=''");
            }
            else if (el.type === undefined) {
                eval(sScope + "." + model + "=$(el).html()");
            }
            else {
                eval(sScope + "." + model + "=$(el).inputmask('unmaskedvalue')");
            }
        });
    },
    // 정의한 모델의 컨트롤 조회
    getElementsByModel: function (sModel) {
        return $(this).find("[data-model='" + sModel + "']");
    }
});