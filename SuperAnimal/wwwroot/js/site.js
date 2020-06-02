// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function getResponseCovidJSON() {

    const confirmed = $("#h-confirmed");
    const recovered = $("#h-recovered");
    const critical = $("#h-critical");
    const deaths = $("#h-deaths")
    const lastChange = $("#h-last-change");
    const lastUpdate = $("#h-last-update");


    axios.get('/home/covidjson')
        .then(function (response) {
            // handle success
            console.log(response);

            const data = response.data[0];

            confirmed.text("Confirmed: " + data.confirmed);
            recovered.text("Recovered: " + data.recovered);
            critical.text("Critical: " + data.critical);
            deaths.text("Deaths: "+data.deaths);
            lastChange.text("Last Change: " +data.lastChange);
            lastUpdate.text("Last Update: "+ data.lastUpdate);

        })
        .catch(function (error) {
            // handle error
            console.log(error);
        });

}