import { useState,  useContext } from 'react';
import { UrlContext } from '../store/url_context';
export default function Button({ buttonName, CssClass }) {
    const [buttonClick, setButtonClick] = useState(false);
    const [error, setError] = useState();
    const [resp, setResponse] = useState(null);
    const urlCtx = useContext(UrlContext);

    const handleClick = async () => {
        setButtonClick(true);

        try {
            const response = await fetch(`Main/?longUrl=${urlCtx.longUrl}`, {
                method: 'GET',
                headers: {
                    Accept: 'application/json',
                },
            });
            if (!response.ok) {
                throw new Error(`Error status : ${response.status}`);
            }
            const result = await response.json();
            setResponse(result);

        } catch (err) {
            setError(err.message);
        }

    };

    return (
        <>
            <button className={CssClass} onClick={handleClick}>{buttonName}</button>
            {(buttonClick) ? <p>{resp}</p> : ''}
        </>
    );

}