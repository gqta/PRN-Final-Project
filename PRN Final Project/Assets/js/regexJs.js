let timeout;

// traversing the DOM and getting the input and span using their IDs

let password = document.getElementById('password')
let strengthBadge = document.getElementById('StrengthDisp')

// The strong and weak password Regex pattern checker

let strongPassword = new RegExp('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})')
let mediumPassword = new RegExp('((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{6,}))|((?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9])(?=.{8,}))')

function StrengthChecker(PasswordParameter) {
    // We then change the badge's color and text based on the password strength

    if (strongPassword.test(PasswordParameter)) {
        strengthBadge.style.backgroundColor = "green"
        strengthBadge.textContent = 'Strong'
    } else if (mediumPassword.test(PasswordParameter)) {
        strengthBadge.style.backgroundColor = 'blue'
        strengthBadge.textContent = 'Medium'
    } else {
        strengthBadge.style.backgroundColor = 'red'
        strengthBadge.textContent = 'Weak'
    }
}

function checkPass() {
    var pass = document.getElementById("password").value;
    var rpass = document.getElementById("repassword").value;
    

    if (pass != rpass) {
        document.getElementById("submit").disabled = true;
        $('.missmatch').text("Entered Password is not matching!! Try Again");
    } else {
        $('.missmatch').text("");
        document.getElementById("submit").disabled = false;
    }
}

function ValidateEmail() {
    var email = document.getElementById("email").value;
    if (!/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email)) {
        document.getElementById("submit").disabled = true;
        $('.missmatch').text("You have entered an invalid email address!");
    }
 else {
        $('.missmatch').text("");
    document.getElementById("submit").disabled = false;
}
   


// Adding an input event listener when a user types to the  password input 

password.addEventListener("input", () => {

    //The badge is hidden by default, so we show it

    strengthBadge.style.display = 'block'
    clearTimeout(timeout);

    //We then call the StrengChecker function as a callback then pass the typed password to it

    timeout = setTimeout(() => StrengthChecker(password.value), 500);

    //Incase a user clears the text, the badge is hidden again

    if (password.value.length !== 0) {
        strengthBadge.style.display != 'block'
    } else {
        strengthBadge.style.display = 'none'
    }
});