import React, {useState} from 'react'
import FormInput from '../../inputs/form/FormInput'
import FormBtn from '../../buttons/form/FormBtn'
import FormLabel from '../../labels/form/FormLabel'
import styles from './SignUpForm.module.css'

/**
 * Форма регистрации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 * @param {*} error - callback-функция для передачи возможной ошибки
 */
const SignUpForm = ({accept, error}) => {
    const [surname, setSurname] = useState('')
    const [name, setName] = useState('')
    const [patronymic, setPatronymic] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    /**
     * Подтверждение формы регистрации
     */
    const SignUp = (e) => {
        e.preventDefault()

        const wordRegex = /[А-Я][а-я]+/g
        if (surname.match(wordRegex) == null){
            error('Фамилия не валидная')
            return false;
        }
        if (name.match(wordRegex) == null){
            error('Имя не валидно')
            return false;
        }
        if (name.match(wordRegex) == null){
            error('Отчество не валидно')
            return false;
        }

        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+.[A-Za-z]+/g
        if (email.match(emailRegex) == null){
            error("Почта не валидная")
            return false;
        }

        const passRegex = /[\S+]{8,16}/g
        if (password.match(passRegex) == null){
            error("Пароль не валидный")
            return false;
        }

        const userInfo = {
            email: email,
            password: password,
            surname: surname,
            name: name,
            patronymic: patronymic
        }
        accept(userInfo)
    }

    return(
        <form className={`grid grid-cols-1 ${styles.myForm}`}>
            <div className='grid place-items-center'>
                <h1 className={styles.myHeader}>Регистрация</h1>
                <hr/>
            </div>

            <FormLabel title={'Фамилия'}/>
            <div className='grid place-items-center'>
                <FormInput
                    type="text"
                    onChange={e => setSurname(e.target.value)}
                    placeholder='Введите фамилию...'/>
            </div>

            <FormLabel title={'Имя'}/>
            <div className='grid place-items-center'>
                <FormInput
                    type="text"
                    onChange={e => setName(e.target.value)}
                    placeholder='Введите имя...'/>
            </div>

            <FormLabel title={'Отчество'}/>
            <div className='grid place-items-center'>
                <FormInput
                    type="text"
                    onChange={e => setPatronymic(e.target.value)}
                    placeholder='Введите отчество...'/>
            </div>
            
            <FormLabel title={'Почта'}/>
            <div className='grid place-items-center'>
                <FormInput 
                    type="email"
                    onChange={e => setEmail(e.target.value)}
                    placeholder='Введите почту...'/>
            </div>

            <FormLabel title={'Пароль'}/>
            <div className='grid place-items-center'>
                <FormInput
                    type="password"
                    onChange={e => setPassword(e.target.value)}
                    placeholder='Введите пароль...'/>
            </div>
            
            <div className='grid place-items-center'>
                <FormBtn 
                    onClick={SignUp}
                    children={"Зарегистрироваться"}/>
            </div>
        </form>
    )
}


export default SignUpForm