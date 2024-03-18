import { useState } from 'react';
import Alert from '@mui/material/Alert';

 // Will be looking into a better way of redirecting
function redirect(url) {
    window.location.href = url;
}
function isValidURL(urlFromApiResponse) {
    let url;
    try {
        url = new URL(urlFromApiResponse);
    } catch (_) {
        return false;
    }
    return url.protocol === "https:" || url.protocol === "http:";
}
export default function UrlInput() {
    const [submission, setSubmission] = useState(false);
    const [response, setFormResponse] = useState(null);
    const [error, setError] = useState();
    async function makeApiCall(url){
        try {
            const response = await fetch(`Main/?longUrl=${url}`, {
                method: 'GET',
                headers: {
                    Accept: 'application/json',
                },
            });
            if (!response.ok) {
                throw new Error(`Error status : ${response.status}`);
            }
            const result = await response.json();
            if (result !== null && isValidURL(result.longURL)) redirect(result.longURL);
            // This will most likely be replaced (TBD) as of right now I have it in for testing purposes
            setFormResponse(result.shortURL);
        } catch (err) {
            setError(err.message);
        }
    };
    function handleSubmission(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const enteredUrl = formData.get('longUrl');
        makeApiCall(enteredUrl);
        setSubmission(true);
    }

    return (
        <form onSubmit={handleSubmission}>
            <div id="main-box">
                <div className="controls">
                    <p>
                      <label>URL to shorten</label>
                      <input type="url" name='longUrl' required/>
                    </p>
                    <button className="sub">Shorten</button>
                    {(submission) ? <Alert severity="success">Successful submission</Alert> : null}
                </div>
            </div>
        </form>
    );
}