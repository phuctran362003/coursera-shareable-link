document.getElementById("generateLink").addEventListener("click", () => {
    chrome.tabs.query({ active: true, currentWindow: true }, (tabs) => {
        const url = tabs[0].url;
        fetch("/api/shareablelink/generate", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ originalUrl: url }),
        })
            .then((response) => response.json())
            .then((data) => {
                document.getElementById("linkOutput").textContent = data.shareableLink;
            })
            .catch((error) => console.error("Error:", error));
    });
});
