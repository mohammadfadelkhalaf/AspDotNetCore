const formerrorhandler = (element, validationResult) => {
    let element = document.querySelector('[data-valmsg-for="${element.name}"]')
    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-vaid')
        spanElement.innerHTML = ''


    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-vaid')
        spanElement.innerHTML = e.target.dataset.valRequired
    }
}


const lengthvalidator = (element, minlength = 2) => {
    if (element.value.length >= minlength)
        return true

    return false
}
const comparevalidator = (value, comparevalue) => {
    if (value === comparevalue)
        return true

    return false
}
//const checkvalidator = (element) => {
//    if (element.checked)
//        return true

//    return false
//}

    cont textvalidator = (element, minlength=2) => {
        if (element.value.length >= minlength)
            return formErrorHandler(element, true)

        formErrorHandler(element, false)
}

const checkboxvalidator = (element) => {
    if (element.checked)
        formErrorHandler(element, true)
     formErrorHandler(element, false)
}

let forms = document.querySelector('form')
let inputs = forms[0].querySelector('input')
inputs.forEach(input => {
    if (input.dataset.val == true) {
        if (input.type === 'checkbox')
            input.addEventListener('change', e => {
                checkboxvalidator(e.target)
            })
    }
    else {
        input.addEventListener('keyup', e => {
            swith(e.target.type)
            case: 'text'
            textvalidator(e.target)
            break
           case: 'password'
            comparevalidator(e.target)
            break
        }
        )}
            
       
    
})
