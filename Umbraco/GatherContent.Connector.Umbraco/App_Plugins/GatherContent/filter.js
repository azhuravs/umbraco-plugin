﻿(function () {
    angular.module('umbraco')
        .filter('filterByTypes', function () {
            return function (umbItems, gcItem) {
                var result = [];
                angular.forEach(umbItems, function (umbItem, index) {
                    switch (gcItem.Type) {
                        case 'text':
                            if (umbItem.Type == 'Umbraco.TinyMCEv3'
                                || umbItem.Type == 'Umbraco.TextboxMultiple'
                                || umbItem.Type == 'Umbraco.Textbox') {
                                result.push(umbItem);
                            }
                            break;
                        case 'section':
                            if (umbItem.Type == 'Umbraco.TinyMCEv3'
                                || umbItem.Type == 'Umbraco.TextboxMultiple'
                                || umbItem.Type == 'Umbraco.Textbox')
                                result.push(umbItem);
                            break;
                        case 'choice_checkbox':
                            if (umbItem.Type == 'Umbraco.DropDownMultiple')
                                result.push(umbItem);
                            //break;
                        case 'choice_radio':
                            if (umbItem.Type == 'Umbraco.DropDown'
                                || umbItem.Type == 'Umbraco.CheckBoxList'
                                || umbItem.Type == 'Umbraco.RadioButtonList'
                                || umbItem.Type == 'Umbraco.DropdownlistPublishingKeys')
                                result.push(umbItem);
                            break;

                        case 'files':
                            if (umbItem.Type == 'Umbraco.MultipleMediaPicker'
                                || umbItem.Type == 'Umbraco.MediaPicker')
                                result.push(umbItem);
                            break;
                        default:
                            break;
                    }
                });
                return result;
            }
        })
        .filter('filterByGCContentId', function () {
            return function (items) {
                var result = [];
                angular.forEach(items, function (item) {
                    if (!(item.Name == 'GC Content Id' || item.Name == 'Mapping Id'))
                        result.push(item);
                });
                return result;
            }
        })
        .filter('filterBySelected', function () {
            return function (items) {
                var result = [];
                angular.forEach(items, function (item) {
                    if (item.Checked || item.checked) {
                        result.push(item);
                    }
                });
                return result;
            }
        })
        .filter('filterByResult', function () {
            return function (items, success) {
                var result = [];
                angular.forEach(items, function (item) {
                    if (item.IsImportSuccessful == success) {
                        result.push(item);
                    }
                });
                return result;
            }
        });
})()