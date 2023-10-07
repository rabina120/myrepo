ko.bindingHandlers.formValidate = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var value = valueAccessor();
        var callback = ko.unwrap(value);
        var trackElement = '';
        //var callback = allBindings.get('callback');       
        $(element).validate({
            submitHandler: callback,
            showErrors: function (errorMap, errorList) {
                var errorString = '';
                // Clean up any tooltips for valid elements
                $.each(this.validElements(), function (index, element) {
                    var $element = $(element);
                    $element.data("title", "") // Clear the title - there is no error associated anymore
                  .removeClass("error")
                  .tooltip("destroy");
                });
                // Create new tooltips for invalid elements
                $.each(errorList, function (index, error) {
                    var $element = $(error.element);
                    errorString += error.message + "\r\n";
                    $element.tooltip("destroy") // Destroy any pre-existing tooltip so we can repopulate with new tooltip content
                  .data("title", error.message)
                  .addClass("error")
                  .tooltip(); // Create a new tooltip based on the error messsage we just set in the title
                    //                    
                    //                    if (index === 0) {
                    //                        trackElement = $element;
                    //                    }

                });
                //trackElement.focus();
            }
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        // This will be called once when the binding is first applied to an element,
        // and again whenever the associated observable changes value.
        // Update the DOM element based on the supplied values here.
    }
};

ko.bindingHandlers.amount = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var state = valueAccessor();
        $(element).bind("keydown", function (event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }
            var code = parseInt(event.keyCode);

            if (code >= 48 && code <= 57 || code >= 96 && code <= 105)
                return true;
            if (code == 8 || code == 46 || code == 9 || (code >= 37 && code <= 40))
                return true;
            if (state) {
                if (code == 110 || code == 190) {
                    if ($(this).val().indexOf(".") >= 0)
                        event.preventDefault();
                    else
                        return true;
                }
            }
            event.preventDefault();
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var state = valueAccessor();
        $(element).bind("keydown", function (event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }
            var code = parseInt(event.keyCode);

            if (code >= 48 && code <= 57 || code >= 96 && code <= 105)
                return true;
            if (code == 8 || code == 46 || code == 9 || (code >= 37 && code <= 40))
                return true;
            if (state) {
                if (code == 110 || code == 190) {
                    if ($(this).val().indexOf(".") >= 0)
                        event.preventDefault();
                    else
                        return true;
                }
            }
            event.preventDefault();
        });
    }
};

ko.bindingHandlers.count = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var state = valueAccessor();
        $(element).bind("keydown", function (event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }
            var code = parseInt(event.keyCode);

            if (code >= 48 && code <= 57 || code >= 96 && code <= 105)
                return true;
            if (code == 8 || code == 46 || code == 9 || (code >= 37 && code <= 40))
                return true;
            if (code == 110 || code == 190) {
                if ($(this).val().indexOf("") >= 0)
                    event.preventDefault();
                else
                    return true;
            }
            event.preventDefault();
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var state = valueAccessor();
        $(element).bind("keydown", function (event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }
            var code = parseInt(event.keyCode);

            if (code >= 48 && code <= 57 || code >= 96 && code <= 105)
                return true;
            if (code == 8 || code == 46 || code == 9 || (code >= 37 && code <= 40))
                return true;
            if (code == 110 || code == 190) {
                if ($(this).val().indexOf("") >= 0)
                    event.preventDefault();
                else
                    return true;
            }
            event.preventDefault();
        });
    }
};