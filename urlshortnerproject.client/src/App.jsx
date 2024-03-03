import Header from './components/Header.jsx'
import UrlInput from './components/UrlInput.jsx';
import './App.css';

function App() {
    return (
        <>
            <Header />
            <main>
                <UrlInput />
            </main>
        </>
    );
}
/*function App() {
    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);
    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }
}
*/

export default App;