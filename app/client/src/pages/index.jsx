import { Route, Routes, Navigate } from "react-router-dom"
import ClientRoutes from "@/shared/routes/Routes.js"

const Routing = () => {
    return (
        <Routes>
            {ClientRoutes.map(route => 
                <Route key={route.path} path={route.path} element={<route.element />} />
            )}
            <Route path='/*' element={<Navigate to='signIn' replace />} />
        </Routes>
    )
}

export default Routing