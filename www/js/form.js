function formhash(form, password) {
    // Create a new element input, this will be our hashed password field. 
    var p = document.createElement("input");
 
    // Add the new element to our form. 
    form.appendChild(p);
    p.name = "p";
    p.type = "hidden";
    p.value = hex_sha512(password.value);
 
    // Make sure the plaintext password doesn't get sent. 
    password.value = "";
 
    // Finally submit the form. 
    form.submit();
}
 
function regformhash(password, conf) {
     // Check each field has a value
    if (  password == ''  || 
          conf == '') {
 
        alert('You must provide all the requested details. Please try again');
        return "false";
    }
 
    // Check password and confirmation are the same
    if (password != conf) {
        alert('Your password and confirmation do not match. Please try again');
        return "false";
    }
 
    // Create a new element input, this will be our hashed password field. 
    return hex_sha512(password);;
}