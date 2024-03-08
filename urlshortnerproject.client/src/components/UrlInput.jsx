import { useState } from 'react';
export default function UrlInput() {
    const [submission, setSubmission] = useState(false);
    const [response, setFormResponse] = useState();
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
            setFormResponse(result);
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
                      <input type="text" name='longUrl'/>
                    </p>
                    <button className="sub">Shorten</button>
                    {(submission) ? <p>{response}</p> : null}
                </div>
            </div>
        </form>
    );
}