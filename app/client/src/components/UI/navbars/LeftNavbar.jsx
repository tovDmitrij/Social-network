import React from 'react'
import { LeftMenuButton } from '../buttons/LeftMenuButton'


export const LeftNavbar = () => {
    return (
        <div className='grid col-span-2 place-items-end'>
          <LeftMenuButton 
              direct='/profile/:id' 
              text='Мой профиль' />
          <LeftMenuButton 
              direct='/profile/:id/friends' 
              text='Мои друзья' />
          <LeftMenuButton 
              direct='/profile/:id/conversations' 
              text='Мои переписки' />
          <LeftMenuButton 
              direct='/profile/:id/groups' 
              text='Мои группы' />
        </div>
    )
}