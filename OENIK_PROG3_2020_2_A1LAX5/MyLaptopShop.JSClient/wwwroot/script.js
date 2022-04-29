let brands = [];
let connection = null;
setupSignalR();

let brandIdToUpdate = -1;

getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60327/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });
    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BrandUpdated", (user, message) => {
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
    await fetch('http://localhost:60327/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            //console.log(brands);
            display();
        });
}




function display() {
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.foundationYear
            + "</td><td>" + t.headquarters + "</td><td>"
        + t.ceoName + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Remove</button>`
        + `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
        console.log(t.name);
    });
}


function create() {
    let bname = document.getElementById('brandname').value;
    let foundyear = document.getElementById('foundyear').value;
    let hq = document.getElementById('headq').value;
    let ceo = document.getElementById('ceoname').value;
    fetch('http://localhost:60327/brand', {
         method: 'POST',
         headers: {'Content-Type': 'application/json',},
         body: JSON.stringify(
                { name: bname, foundationYear: foundyear, headquarters: hq,ceoName: ceo}),})
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
    fetch('http://localhost:60327/brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('ubrandname').value = brands.find(t => t[`id`] == id)['name'];
    document.getElementById('ufoundyear').value = brands.find(t => t[`id`] == id)['foundationYear'];
    document.getElementById('uheadq').value = brands.find(t => t[`id`] == id)['headquarters'];
    document.getElementById('uceoname').value = brands.find(t => t[`id`] == id)['ceoName'];
    document.getElementById("updateformdiv").style.display = 'flex';
    brandIdToUpdate = id;
}

function update() {
    document.getElementById("updateformdiv").style.display = 'none';
    let bname = document.getElementById('ubrandname').value;
    let foundyear = document.getElementById('ufoundyear').value;
    let hq = document.getElementById('uheadq').value;
    let ceo = document.getElementById('uceoname').value;
    fetch('http://localhost:60327/brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: brandIdToUpdate, name: bname, foundationYear: foundyear, headquarters: hq, ceoName: ceo }),
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
