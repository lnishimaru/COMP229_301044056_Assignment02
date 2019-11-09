$('#AddIngredient').click(function ()
{
    var ingredients = $('.lines');
    var count = ingredients.length;
    var clone = ingredients.first().clone();
    clone.html($(clone).html().replace(/\[0\]/g, '_' + count + ']'));
    clone.html($(clone).html().replace(/"_0__"/g, '_' + count + '__'));
    lines.last().after(clone);
    clone.find('input').val('');
})
