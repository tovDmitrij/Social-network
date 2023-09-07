import AppHeader from '@/widgets/header'
import ProfileAvatarWidget from "@/widgets/profile/avatar/index"
import ProfileAboutWidget from "@/widgets/profile/about/index"
import ProfileFriendsWidget from "@/widgets/profile/friends/index"
import ProfilePostsWidget from "@/widgets/profile/posts/index"


const ProfilePage = () => {
    return (
        <div>
            <AppHeader />
            <div className='grid grid-cols-2'>
                <ProfileAvatarWidget />
                <ProfileAboutWidget />
                <ProfileFriendsWidget />
                <ProfilePostsWidget />
            </div>
        </div>
    )
}

export default ProfilePage