let shelters = [];
let connection = null;
let shelterIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62480/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AnimalShelterCreated", (user, message) => {
        getdata();
    });

    connection.on("AnimalShelterDeleted", (user, message) => {
        getdata();
    });

    connection.on("AnimalShelterUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });

    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:62480/animalshelter')
        .then(x => x.json())
        .then(y => {
            shelters = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    shelters.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.shelterId + "</td><td>"
            + t.shelterName + "</td><td>"
            + t.address + "</td><td>"
            + t.phoneNumber + "</td><td>"
            + t.taxNumber + "</td><td>"
            + `<button type="button" onclick="showupdate(${t.shelterId})">Update</button>`
            + `<button type="button" onclick="remove(${t.shelterId})">Delete</button>` +
            "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('shelterName').value;
    let name2 = document.getElementById('address').value;
    let name3 = document.getElementById('phoneNumber').value;
    let name4 = document.getElementById('taxNumber').value;
    fetch('http://localhost:62480/animalshelter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                shelterName: name,
                address: name2,
                phoneNumber: name3,
                taxNumber: name4
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showupdate(id) {
    document.getElementById('shelterNameToUpdate').value = shelter.find(t => t['shelterId'] == id)['shelterName'];
    document.getElementById('addressToUpdate').value = shelter.find(t => t['shelterId'] == id)['address'];
    document.getElementById('phoneNumberToUpdate').value = shelter.find(t => t['shelterId'] == id)['phoneNumber'];
    document.getElementById('taxNumberToUpdate').value = shelter.find(t => t['shelterId'] == id)['taxNumber'];
    document.getElementById('updateformdiv').style.display = 'flex';
    shelterIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('shelterNameToUpdate').value;
    let name2 = document.getElementById('addressToUpdate').value;
    let name3 = document.getElementById('phoneNumberToUpdate').value;
    let name4 = document.getElementById('taxNumberToUpdate').value;
    fetch('http://localhost:62480/animalshelter', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                shelterId: shelterIdToUpdate,
                shelterName: name,
                address: name2,
                phoneNumber: name3,
                taxNumber: name4
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:62480/animalshelter/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryOne() {
    document.getElementById('one').innerHTML = "";
    fetch('http://localhost:62480/stat/avarageageofdogsatallshelters')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            let avg = 0;
            data.forEach(x => avg += x.avarageAge);
            avg /= data.length;
            document.getElementById('one').innerHTML += avg;
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryTwo() {
    document.getElementById('two').innerHTML = "";
    fetch('http://localhost:62480/stat/mostcatsadoptedby')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('two').innerHTML += data.firstName + ' ' + data.lastName;
            data.forEach(x => { document.getElementById('two').innerHTML += (x.title + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryThree() {
    document.getElementById('three').innerHTML = "";
    fetch('http://localhost:62480/stat/whichownersadoptedpetbefore2015')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            data.forEach(x => { document.getElementById('three').innerHTML += (x + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryFour() {
    document.getElementById('four').innerHTML = "";
    fetch('http://localhost:62480/stat/avarageageofpets')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('four').innerHTML += data;
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryFive() {
    document.getElementById('five').innerHTML = "";
    fetch('http://localhost:62480/stat/dogsofowner/' + document.getElementById('fiveInput').value)
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            data.forEach(x => { document.getElementById('five').innerHTML += (x.type + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function QuerySix() {
    document.getElementById('six').innerHTML = "";
    fetch('http://localhost:62480/stat/avarageagebypetsatoneshelter/' + document.getElementById('sixInput').value)
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('six').innerHTML += data
        })
        .catch((error) => { console.error('Error:', error); });
}