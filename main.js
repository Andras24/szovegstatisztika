document.getElementById('textForm').addEventListener('submit', async function (e) {
    e.preventDefault();
    const text = document.getElementById('text-input').value;
    const response = await fetch('http://localhost:5000/TextStats', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ text })
    });
    const data = await response.json();
    displayResult(data);
});

function displayResult(data) {
    let html = `
        <h2>Eredm�nyek</h2>
        <table class="table">
            <tr><th>Szavak sz�ma</th><td>${data.wordCount}</td></tr>
            <tr><th>Karakterek sz�ma</th><td>${data.characterCount}</td></tr>
            <tr><th>�tlagos mondathossz</th><td>${data.averageSentenceLength.toFixed(2)}</td></tr>
            <tr><th>�tlagos sz�hossz</th><td>${data.averageWordLength.toFixed(2)}</td></tr>
        </table>
        <h3>Leggyakoribb szavak</h3>
        <table class="table table-striped"><thead><tr><th>Sz�</th><th>Gyakoris�g</th></tr></thead><tbody>`;
    for (const [word, count] of Object.entries(data.mostCommonWords)) {
        html += `<tr><td>${word}</td><td>${count}</td></tr>`;
    }
    html += `</tbody></table>
        <h3>Leggyakoribb szavak diagramja</h3>
        <div class="d-flex align-items-end" style="height:200px;">`;
    const max = Math.max(...Object.values(data.mostCommonWords));
    for (const [word, count] of Object.entries(data.mostCommonWords)) {
        const height = (count / max) * 180;
        html += `
            <div class="mx-2 text-center" style="width:40px;">
                <div style="background:#0d6efd;height:${height}px;"></div>
                <small>${word}</small>
            </div>
        `;
    }
    html += `</div>`;
    document.getElementById('result').innerHTML = html;
}
