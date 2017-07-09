var defaults = {
animationDuration: 350,
headerOpacity: 0.25,
fixedHeaders: false,
headerSelector: function (item) { return item.children("h3").first(); },
itemSelector: function (item) { return item.children(".pivot-item"); },
headerItemTemplate: function () { return $("<span class='header' />"); },
pivotItemTemplate: function () { return $("<div class='pivotItem' />"); },
itemsTemplate: function () { return $("<div class='items' />"); },
headersTemplate: function () { return $("<div class='headers' />"); },
controlInitialized: undefined,
selectedItemChanged: undefined
};
$(function () {
$("div.metro-pivot").metroPivot(defaults);
});