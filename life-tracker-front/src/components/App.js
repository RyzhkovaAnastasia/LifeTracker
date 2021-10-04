import RegistrationForm from './RegistrationForm';
import LoginForm from './LoginForm';
import Home from './Home'
import GuardedRoute from './AuthGuard'
import { useState } from 'react';
import { Switch, Route, Redirect, BrowserRouter } from 'react-router-dom';

const App = () => {

    const [isAutheticated, setisAutheticated] = useState(false);

    return (
        <BrowserRouter>
            <Switch>
                <GuardedRoute path="/Home" component={Home} isAutheticated />
                <Route path="/Login" component={LoginForm} isAuth={setisAutheticated}/>
                <Route path="/" component={RegistrationForm} isAuth={setisAutheticated} />
            </Switch>
        </BrowserRouter>
    );
}

export default App;