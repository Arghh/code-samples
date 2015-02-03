/*Addressbook with few random contacts based on codecademy course on javascript*/
var bob = {
    firstName: "Bob",
    lastName: "Jones",
    phoneNumber: "(650) 777-7777",
    email: "bob.jones@example.com"
};

var mary = {
    firstName: "Mary",
    lastName: "Johnson",
    phoneNumber: "(650) 888-8888",
    email: "mary.johnson@example.com"
};

var contacts = [bob, mary];

function printPerson(person) {
    console.log(person.firstName + " " + person.lastName);
}
/*prints all contacts*/
function list() {
	var contactsLength = contacts.length;
	for (var i = 0; i <= contactsLength; i++) {
		printPerson(contacts[i]);
	}
}
/*search for people in your list*/
function search(lastName) {
    var contactsLength = contacts.length;
    for (var i = 0; i <= contactsLength; i++) {
        if(lastName === contacts[i].lastName) {
            return printPerson(contacts[i]); }
        else { return "Did not find anyone like that"};    
    }
    
}

/*add people to your contacts list*/
function add(firstName, lastName, email, phoneNumber) {
    contacts[contacts.length] = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        phoneNumber: phoneNumber
    };
};



add("PeeterASD","Mees","asdasd@gmail.com","112");
list();

