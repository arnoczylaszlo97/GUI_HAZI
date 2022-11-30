let clubs = [];
let connection = null;
let clubIdToUpdate = -1;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4894/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ClubCreated", (user, message) => {
        getData();
    });

    connection.on("ClubDeleted", (user, message) => {
        getData();
    });

    connection.on("ClubUpdated", (user, message) => {
        getData();
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

async function getData() {
    await fetch('http://localhost:4894/club/')
        .then(x => x.json())
        .then(y => {
            clubs = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    clubs.forEach(c => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + c.club_ID + "</td><td>" + c.club_Name + "</td><td>" + c.manager + "</td><td>" +
            c.owner + "</td><td>" + c.value + "</td><td>" + c.league_ID + "</td><td>" +
            `<button type="button" onclick="remove(${c.club_ID})">Delete</button>` +
            `<button type="button" onclick="showUpdate(${c.club_ID})">Update</button>` + "</td></tr>";
    });
}

function create() {
    let Name = document.getElementById('clubName').value;
    let Value = document.getElementById('clubValue').value;
    let Owner = document.getElementById('clubOwner').value;
    let Manager = document.getElementById('clubManager').value;
    let LeagueID = document.getElementById('leagueID').value;

    fetch('http://localhost:4894/club/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                club_Name: Name,
                value: Value,
                owner: Owner,
                manager: Manager,
                league_ID: LeagueID
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:4894/club/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showUpdate(id) {
    document.getElementById('clubNameToUpdate').value = clubs.find(c => c['club_ID'] == id)['club_Name'];
    document.getElementById('clubManagerToUpdate').value = clubs.find(c => c['club_ID'] == id)['manager'];
    document.getElementById('clubOwnerToUpdate').value = clubs.find(c => c['club_ID'] == id)['owner'];
    document.getElementById('clubValueToUpdate').value = clubs.find(c => c['club_ID'] == id)['value'];
    document.getElementById('leagueIDToUpdate').value = clubs.find(c => c['club_ID'] == id)['league_ID'];

    document.getElementById('updateformdiv').style.display = 'flex';
    document.getElementById('updateButton').style.display = 'flex';

    clubIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    document.getElementById('updateButton').style.display = 'none';

    let Name = document.getElementById('clubNameToUpdate').value;
    let Value = document.getElementById('clubValueToUpdate').value;
    let Owner = document.getElementById('clubOwnerToUpdate').value;
    let Manager = document.getElementById('clubManagerToUpdate').value;
    let LeagueID = document.getElementById('leagueIDToUpdate').value;

    fetch('http://localhost:4894/club', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                club_ID: clubIdToUpdate,
                club_Name: Name,
                value: Value,
                owner: Owner,
                manager: Manager,
                league_ID: LeagueID
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

