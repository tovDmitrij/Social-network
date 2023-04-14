import { useState } from "react";


/**
 * Хук для запросов к API
 * @param {*} callback - функция, во время выполнения которой будет показываться "крутилка" и ловиться ошибки
 * @returns {*} [fetching, isLoading, error]
 */
export const useFetching = (callback) => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('')

    const fetching = async (...args) => {
        try {
            setIsLoading(true)
            await callback(...args)
        } catch (e) {
            setError(e.message)
        } finally {
            setIsLoading(false)
        }
    }

    return [fetching, isLoading, error]
}