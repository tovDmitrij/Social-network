import React from 'react'
import classes from './FormInput.module.css'


/**
 * Инпут для различных форм заполнения
 */
const FormInput = React.forwardRef((props, ref) => {
    return (
        <input ref={ref} className={classes.myInput} {...props} />
    )
})


export default FormInput