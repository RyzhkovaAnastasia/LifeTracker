import { useHistory } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faCircleCheck, faUserEdit, faList, faLockOpen,
} from '@fortawesome/free-solid-svg-icons';
import { useState, useEffect } from 'react';
import { deleteToken, getUser } from '../services/AuthService';
import Dashboard from './Dashboard';
import UserInfo from './UserInfo';

const Home = (props) => {
  const history = useHistory();

  const [user, setUserObj] = useState(null);
  function getUserObj() {
    getUser().then((response) => {
      setUserObj(response.data);
    });
  }
  useEffect(getUserObj, []);

  const onLogout = () => {
    deleteToken();
    setTimeout(() => history.replace('/Login'), 1000);
    props.logout();
  };

  const onOpenAccount = () => {
    // todo open modal Account
  };

  const onOpenStats = () => {
    // todo open stats modal
  };

  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
        <div className="navbar-nav">
          <button className="btn btn-primary ml-auto">
            <FontAwesomeIcon icon={faCircleCheck} />
            {' '}
            Life Tracker
          </button>
          <button className="btn btn-primary ml-auto" onClick={onOpenAccount}>
            <FontAwesomeIcon icon={faUserEdit} />
            {' '}
            Account
          </button>
          <button className="btn btn-primary ml-auto" onClick={onOpenStats}>
            <FontAwesomeIcon icon={faList} />
            {' '}
            Stats
          </button>
          <button className="btn btn-primary ml-auto" onClick={onLogout}>
            <FontAwesomeIcon icon={faLockOpen} className="text-warning" />
            {' '}
            Logout
          </button>
        </div>
      </nav>
      <UserInfo user={user} />
      <Dashboard {...user} />
    </div>
  );
};

export default Home;
