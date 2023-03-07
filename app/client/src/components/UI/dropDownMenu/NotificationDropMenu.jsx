import React from 'react'
import { LogoImage } from '../images/LogoImage'
import ImageSize from '../../../enums/ImageSize'


/**
 * Выпадающий список уведомлений
 * @param posts - посты
 */
export function NotificationDropMenu({posts}) {
    return (
        <div className='grid grid-cols-2 justify-items-center items-center'>
            <div>
                <LogoImage src='/images/notification_ringbell.webp' size={ImageSize.SMALL} />
            </div>
            <div>
                {posts.length}
            </div>

            {posts.map((post) =>
                {/*<MyNotification key={post.id} />*/}
            )}
        </div>
    )
}