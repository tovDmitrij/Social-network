import { Link } from 'react-router-dom';
import ClientRoutes from '@/shared/routes/Routes.js'
import styles from './styles.module.scss'

const AppHeader = () => {
    return(
        <>
            {ClientRoutes.map(route =>
                <Link key={route.path} to={route.path}>
                    <button>{route.path}</button>
                </Link>
            )}
        </>
    )
}

export default AppHeader;