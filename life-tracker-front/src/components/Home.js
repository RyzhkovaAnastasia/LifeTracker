import { logoutUser } from '../services/AuthService'
import { useHistory } from 'react-router-dom';
const Home = (props) => {
    const history = useHistory();
    const onClick = () => {
        logoutUser()
            .then(() => {
                setTimeout(() => history.replace("/Login"), 1500);
                props.logout();
            })
            .catch(err => {
                console.log(err.response.data);
            });
    }
    return (<button onClick={onClick}>Logout</button>);
}

export default Home;