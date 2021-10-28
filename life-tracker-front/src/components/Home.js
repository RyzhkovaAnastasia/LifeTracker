import { deleteToken } from '../services/AuthService'
import { useHistory } from 'react-router-dom';
import Dashboard from './Dashboard';
import UserInfo from './UserInfo';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircleCheck, faUserEdit, faList, faLockOpen } from '@fortawesome/free-solid-svg-icons'
import { getUser } from '../services/AuthService';
import { useState, useEffect } from 'react';

const Home = (props) => {

    const history = useHistory();

    const [user, setUserObj] = useState(null); 
    useEffect(getUserObj, []);

    function getUserObj() {
        getUser().then(user => {
            setUserObj(user.data);
        });
    }

    const onLogout = () => {
        deleteToken();
        setTimeout(() => history.replace("/Login"), 1000);
        props.logout();
    }

    const onOpenAccount = () => {
        // todo open modal Account
    }

    const onOpenStats = () => {
        // todo open stats modal
    }

    return (
        <div>
            <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
                <div className="navbar-nav">
                    <button className="btn btn-primary ml-auto" >
                        <FontAwesomeIcon icon={faCircleCheck} /> Life Tracker
                    </button>
                    <button className="btn btn-primary ml-auto" onClick={onOpenAccount}>
                        <FontAwesomeIcon icon={faUserEdit} /> Account
                    </button>
                    <button className="btn btn-primary ml-auto" onClick={onOpenStats}>
                        <FontAwesomeIcon icon={faList} /> Stats
                    </button>
                    <button className="btn btn-primary ml-auto" onClick={onLogout}>
                        <FontAwesomeIcon icon={faLockOpen} className="text-warning" /> Logout
                    </button>
                </div>
            </nav>
            <UserInfo user={user}/>
            <Dashboard user={user}/>
        </div>
    );
}

export default Home;