import { useState, useEffect } from 'react';
export default function Button({ buttonName, CssClass }) {
    const [buttonClick, setButtonClick] = useState(false);
    const [resp, setResponse] = useState(null);

    function handleClick() {
        setButtonClick(true);
    }

    useEffect(() => {
        fetch('Main')
            .then((response) => response.json())
            .then((actualData) => setResponse(actualData))
            .catch (error => console.error(error));
    }, []);

    return (
        <>
            <button className={CssClass} onClick={handleClick}>{buttonName}</button>
            {(buttonClick) ? <p>{resp}</p> : ''}
        </>
    );

}