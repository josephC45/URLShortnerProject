import { useState } from 'react';
import { UrlContext } from '../store/url_context'
import Button from './Button';
export default function UrlInput() {
    const [shortenState, setShortenState] = useState({
        longUrl: null,
    });
    function handleShortenInput(context) {
        setShortenState(context.target.value);
    } 

    const urlCtx = {
        longUrl: shortenState
    };

    return (
         <UrlContext.Provider value={urlCtx}>
            <div id="main-box">
                <div className="controls">
                    <p>
                      <label>URL to shorten</label>
                      <input onChange={handleShortenInput} type="url"/>
                    </p>
                    <Button CssClass="sub" buttonName="Shorten"/>
                </div>
            </div>
        </UrlContext.Provider>

    );
}