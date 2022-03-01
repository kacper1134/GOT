let resize_function = function () {
    let main_navigation = $('#main-navigation');

    let navigation_items = Array.from(main_navigation.children());

    navigation_items.forEach((item) => {
        let width = item.offsetWidth;

        let dropdown = item.getElementsByTagName('ul')[0];
        
        if (dropdown === undefined) {
            return;
        }

        let dropdownItems = Array.from(dropdown.getElementsByTagName('li'));

        if (dropdownItems === undefined) {
            return;
        }

        dropdownItems.forEach((item) => {
            $(item).css("width", width);
        })
    });
}

window.addEventListener('resize', resize_function);

$(document).ready(resize_function)
