let brands = [];

getdata();

async function getdata() {
    await fetch('http://localhost:60327/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            console.log(brands);
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
            + t.ceoName + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Remove</button>`+ "</td></tr>";
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
