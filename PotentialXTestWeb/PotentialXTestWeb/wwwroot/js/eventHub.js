"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/eventHub").build();

connection.on("ReceiveMessage", function (user, message) {
    location.reload(true);
});

connection.start();