import { useState } from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import RegistrationForm from './RegistrationForm';
import LoginForm from './LoginForm';
import Home from './Home';
import GuardedRoute from './AuthGuard';

const App = () => {
  const [isAutheticated, setisAutheticated] = useState(false);

  return (
    <BrowserRouter>
      <Switch>
        <GuardedRoute path="/Home" component={Home} auth={isAutheticated}>
          <Home logout={() => setisAutheticated(false)} />
        </GuardedRoute>
        <Route path="/Login">
          <LoginForm login={() => setisAutheticated(true)} />
        </Route>
        <Route exact path="/">
          <RegistrationForm register={() => setisAutheticated(true)} />
        </Route>
      </Switch>
    </BrowserRouter>
  );
};

export default App;
