let backlogArray = [];
let publisherArray = [];
let genreArray = [];

let Backlog = function (pTitle, pPlatform, pFinished, pPublisherID, pGenreID) {
    //this.Id = Math.random().toString(16).slice(5)  // tiny chance could get duplicates!
    this.title = pTitle;
    this.platform = pPlatform;
    this.finished = pFinished;
    this.publisherID = parseInt(pPublisherID);
    this.genreID = parseInt(pGenreID);
}

let Publisher = function (pCountry, pNamePub) {
    this.country = pCountry;
    this.namePub = pNamePub;
}

document.addEventListener("DOMContentLoaded", function () {

    updateBacklogDisplay();
    updatePublisherDisplay();
    updateGenreDisplay();

});
//Displaying Data functions
function updateBacklogDisplay() {
$.get("api/Backlog", function (data, status) {  // AJAX get
    backlogArray = data;  // put the returned server json data into our local array
    let table = document.getElementById('backlogtable');

    //clear old values
    while (table.rows.length > 0) {
        table.deleteRow(0);
    }

    //Inserts labels
    let tr = document.createElement('tr');

    let td1 = document.createElement('td');
    td1.textContent = "[ Title ]";
    tr.appendChild(td1);
    let td2 = document.createElement('td');
    td2.textContent = "[ Country ]";
    tr.appendChild(td2);
    let td3 = document.createElement('td');
    td3.textContent = "[ Publisher ]";
    tr.appendChild(td3)
    let td4 = document.createElement('td');
    td4.textContent = "[ Platform ]";
    tr.appendChild(td4);
    let td5 = document.createElement('td');
    td5.textContent = "[ Genre ]";
    tr.appendChild(td5);
    let td6 = document.createElement('td');
    td6.textContent = "[ Finished? ]";
    tr.appendChild(td6);
    let td7 = document.createElement('td');
    td7.textContent = "[ Manage Entry ]";
    tr.appendChild(td7);

    table.appendChild(tr);
    let idAssign = -1;  //There's probably a much better way of assigning
                        //individual ID's to each <tr> but I can't think of one

    //Inserts games into rows
    for (let entry of backlogArray) {
        idAssign++
        let tr = document.createElement('tr');
        entry.backlogID = idAssign;
        tr.id = entry.backlogID;

        let td1 = document.createElement('td');
        td1.textContent = entry.title;
        tr.appendChild(td1);

        let td2 = document.createElement('td');
        td2.textContent = entry.country;
        tr.appendChild(td2);

        let td3 = document.createElement('td');
        td3.textContent = entry.publisher; 
        tr.appendChild(td3);

        let td4 = document.createElement('td');
        td4.textContent = entry.platform;
        tr.appendChild(td4);

        let td5 = document.createElement('td');
        td5.textContent = entry.genre;
        tr.appendChild(td5);

        if (entry.finished == true) {
            let td6 = document.createElement('td');
            td6.textContent = "Yes";
            tr.appendChild(td6);
        } else {
            let td6 = document.createElement('td');
            td6.textContent = "No";
            tr.appendChild(td6);

            let td7 = document.createElement('button');
            td7.textContent = "Finished";
            td7.id = entry.backlogID;
            td7.setAttribute("onClick", "gameUpdate(true, this.id)");
            tr.appendChild(td7);

            let td8 = document.createElement('button');
            td8.textContent = "Drop Game";
            td8.id = entry.backlogID;
            td8.setAttribute("onClick", "gameUpdate(false, this.id)");
            tr.appendChild(td8);
        }
        table.appendChild(tr);

    }

});
}
function updatePublisherDisplay() {
$.get("api/Publisher", function (data, status) {  // AJAX get
    let publisherSelect = document.getElementById('publisherList');
    publisherArray = data;  // put the returned server json data into our local array

    while (publisherSelect.options.length > 0) {
        publisherSelect.remove(0);
    }

    for (let item of publisherArray) {
        let newOption = document.createElement('option');
        let optionText = document.createTextNode(item.namePub + "\, " + item.country);
        newOption.appendChild(optionText);
        newOption.setAttribute('value', item.publisherID);
        publisherSelect.appendChild(newOption);
    }
});
}
function updateGenreDisplay() {
$.get("api/Genre", function (data, status) {  // AJAX get
    let genreSelect = document.getElementById('genreList');
    genreArray = data;  // put the returned server json data into our local array

    while (genreSelect.options.length > 0) {
        genreSelect.remove(0);
    }

    for (let item of genreArray) {
        let newOption = document.createElement('option');
        let optionText = document.createTextNode(item.genreDesc);
        newOption.appendChild(optionText);
        newOption.setAttribute('value', item.genreID);
        genreSelect.appendChild(newOption);
    }

});
}

//Button functions
function addBacklog(Finished) {
let publisherSelect = document.getElementById('publisherList');
let genreSelect = document.getElementById('genreList');

let newTitle = document.getElementById("title").value;
let newPlatform = document.getElementById("platform").value;
let newPublisherID = publisherSelect.value;
let newGenreID = genreSelect.value;
let newFinished = Finished;

let newBacklog = new Backlog(newTitle, newPlatform, newFinished, newPublisherID, newGenreID); //newGenreID is being mistaken with backlogID!!!
console.log(newBacklog);

console.log("genreSelect = " + genreSelect);
console.log("newGenreID = " + newGenreID);


$.ajax({
    url: "api/Backlog",
    type: "POST",
    data: JSON.stringify(newBacklog),
    contentType: "application/json; charset=utf-8",
    success: function (result) {
        clearAll();
        console.log(result);
        updateBacklogDisplay();
    }
});
}
function addGenre() {
let value = document.getElementById("newGenre").value
$.ajax({
    url: "/api/Genre",
    type: "POST",
    data: JSON.stringify(value),
    contentType: "application/json; charset=utf-8",
    success: function (result) {
        console.log(result);
        clearAll();
        updateGenreDisplay();
    }
});
}
function addPublisher() {
console.log("addPublisher is working :)");

let newCountry = document.getElementById("newCountry").value
let newPubName = document.getElementById("newPubName").value
let newPublisher = new Publisher(newCountry, newPubName)
console.log(newPublisher);

$.ajax({
    url: "api/Publisher",
    type: "POST",
    data: JSON.stringify(newPublisher),
    contentType: "application/json; charset=utf-8",
    success: function (result) {
        console.log(result);
        clearAll();
        updatePublisherDisplay();
    }
});

}
function gameUpdate(bool, findID) { //bool, backlogID
console.log(bool, findID);
if (bool == true) {
    //take backlogID value of entry
    console.log("This is the button for marking " + backlogArray[findID].title + " as FINISHED ");
    backlogArray[findID].finished = true;
    console.log(backlogArray[findID].title + " is now marked as " + backlogArray[findID].finished);
    updateBacklogDisplay();
    console.log(backlogArray[findID]);

    } else {
    console.log("This is the button for marking " + backlogArray[findID].title + " as DROPPED");
    updateBacklogDisplay();
    }
}
//General functions
function clearAll() {
document.getElementById('title').value = "";
document.getElementById('newCountry').value = "";
document.getElementById('newPubName').value = "";
document.getElementById('platform').value = "";
document.getElementById('newGenre').value = '';
}

//Mongo-related
let MongoBacklog = function (pTitle, pCountry, pPublisher, pPlatform, pGenre, pFinished) {
    this.title = pTitle;
    this.country = pCountry;
    this.publisher = pPublisher;
    this.platform = pPlatform;
    this.genre = pGenre;
    this.finished = pFinished;
    console.log(this);
}
function backupButton() { // get all backlog entries in mongo
    $.get("api/MongoBacklogs", function (data, status) {
        let backlogArray = data;
        for (let aBacklog of backlogArray) { // delete one at a time
            $.ajax({
                url: "api/MongoBacklogs/" + aBacklog.id,
                type: "DELETE",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                }
            });
        };
    });

    $.get("api/Backlog", function (data, status) { // get all backlog entries from SQL
        let mongoArray = data;
        for (let aBacklog of mongoArray) {
            let nextMongoBacklog = new MongoBacklog(aBacklog.title, aBacklog.country, aBacklog.publisher, aBacklog.platform, aBacklog.genre, aBacklog.finished);
            $.ajax({
                url: "api/MongoBacklogs",
                type: "POST",
                data: JSON.stringify(nextMongoBacklog),
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    console.log(result);
                }
            });
        }
    });
}
function displayBackupButton() {
    $.get("api/MongoBacklogs", function (data, status) {
        let backlogArray = data;
        let table = document.getElementById('backlogtable');
        while (table.rows.length > 0) { // clear old values first
            table.deleteRow(0);
        }
        let tr = document.createElement('tr'); // create table and headers
        let td1 = document.createElement('td');
        td1.textContent = "Data From Backup";
        tr.appendChild(td1);
        table.appendChild(tr);

        let idAssign = -1;  //There's probably a much better way of assigning
                            //individual ID's to each <tr> but I can't think of one
        for (let entry of backlogArray) {
            idAssign++
            let tr = document.createElement('tr');
            entry.backlogID = idAssign;
            tr.id = entry.backlogID;

            let td1 = document.createElement('td');
            td1.textContent = entry.title;
            tr.appendChild(td1);

            let td2 = document.createElement('td');
            td2.textContent = entry.country;
            tr.appendChild(td2);

            let td3 = document.createElement('td');
            td3.textContent = entry.publisher;
            tr.appendChild(td3);

            let td4 = document.createElement('td');
            td4.textContent = entry.platform;
            tr.appendChild(td4);

            let td5 = document.createElement('td');
            td5.textContent = entry.genre;
            tr.appendChild(td5);

            if (entry.finished == true) {
                let td6 = document.createElement('td');
                td6.textContent = "Yes";
                tr.appendChild(td6);
            } else {
                let td6 = document.createElement('td');
                td6.textContent = "No";
                tr.appendChild(td6);

                let td7 = document.createElement('button');
                td7.textContent = "Finished";
                td7.id = entry.backlogID;
                td7.setAttribute("onClick", "gameUpdate(true, this.id)");
                tr.appendChild(td7);

                let td8 = document.createElement('button');
                td8.textContent = "Drop Game";
                td8.id = entry.backlogID;
                td8.setAttribute("onClick", "gameUpdate(false, this.id)");
                tr.appendChild(td8);
            }
            table.appendChild(tr);
        }
    });
}