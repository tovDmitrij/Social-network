import { BrowserRouter } from "react-router-dom"
import Routing from "../pages"
import styles from './styles.module.scss'

const App = () => {
    return (
        <div className={styles.main}>
            <BrowserRouter>
                <Routing />
            </BrowserRouter>
        </div>
    )
}

export default App