function mascara(t, mask) {
    var i = t.value.length;
    var saida = mask.substring(1, 0);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) != saida) {
        t.value += texto.substring(0, 1);
    }
}

$(".mask-date").unmask().mask("00/00/0000");
$(".mask-datetime").unmask().mask("00/00/0000 00:00");

var phoneMask = function (val) {
    return val.replace(/\D/g, '').length === 13 ? '(00) 00000-0000' : '(00) 0000-00009';
}

$('.mask-phone').unmask().mask(phoneMask, {
    onKeyPress: function (phone, e, field, options) {
        field.mask(phoneMask.apply({}, arguments), options);
    }
});

$('.currency').maskMoney({
    thousands: '.',
    decimal: ',',
    precision: 2,
    allowZero: true,
    allowNegative: false
}).maskMoney('mask');

