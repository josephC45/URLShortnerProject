import { useState } from 'react';
import Button from './Button';
export default function UrlInput() {
    const [shortenState, setShortenState] = useState(null);
    function handleShortenInput(context) {
        setShortenState(context.target.value);
    } 

    return (
        <div id="main-box">
            <div className="controls">
                <p>
                  <label>URL to shorten</label>
                    <input onChange={handleShortenInput} type="url"/>
                </p>
                <Button className="sub" buttonName="Shorten" longUrl={shortenState} />
            </div>
        </div>
    );
}