import React from 'react'
import styles from './FormLabel.module.css'


const FormLabel = ({title, ...props}) => {return( <label className={styles.myLbl} {...props}>{title}</label> )}


export default FormLabel