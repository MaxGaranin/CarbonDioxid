let labels = [];
let data = [];

const ctx = document.getElementById('myChart').getContext('2d');
const chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'line',
    // Configuration options go here
    options: {
        animation: false
    }
});

updateChart();

setInterval(() => {
    fetchDataAndUpdateChart();
    }, 1000);

function updateChart() {
    chart.data = {
        labels: labels,
        datasets: [
            {
                label: 'Измерения CO2 в 102 комнате',
                backgroundColor: 'rgb(255, 99, 132)',
                borderColor: 'rgb(255, 99, 132)',
                data: data,
            }
        ]
    };
    
    chart.update();
}

function fetchDataAndUpdateChart() {
    const requestOptions = {
        method: 'GET',
        redirect: 'follow',
        headers: {
            "Accept": "application/json"
        }
    };
    
    fetch("/carbon", requestOptions)
        .then(response => response.json())
        .then(result => {
            labels = result.map(x => x.date.slice(0, 10));
            data = result.map(x => x.cO2);
            updateChart();
        })
        .catch(error => console.log('error', error));
}