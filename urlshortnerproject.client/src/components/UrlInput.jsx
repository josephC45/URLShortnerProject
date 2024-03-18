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
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    async function makeApiCall(url){
        try {
            setLoading(true);
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
        } finally {
            setLoading(false);
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
                    <div>
                      <label>URL to shorten</label>
                      <input type="url" name='longUrl' required/>
                    </div>
                    <button className="sub" disabled={loading}>Shorten</button>
                    {loading && <span>Loading...</span>}
                    {submission && !loading && <Alert severity="success">Successful submission</Alert>}
                </div>
            </div>
        </form>
    );
}