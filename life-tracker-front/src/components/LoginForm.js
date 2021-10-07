import { loginUser } from '../services/AuthService'
import { Link } from 'react-router-dom';
import { Formik } from 'formik';
import { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useHistory } from 'react-router-dom';

export default function LoginForm(props) {

    const history = useHistory(); 
    const [requestError, setError] = useState(null);

    const onSubmit = (values, { setSubmitting }) => {
        loginUser(values)
            .then(()=>{
                setSubmitting(true);
                setError(null);
                props.login(); 
                toast.success("You are succsessfully logged in!");
                setTimeout(() => history.push('/Home'), 5000);
            })
            .catch(err => {
                setError(err.response.data);
                setSubmitting(false);
            });
    };

    return (
        <div>
            <ToastContainer />
            <Formik
                initialValues={{ emailOrUsername: '', password: ''}}
                validate={values => {
                    const errors = {};
                    if (!values.emailOrUsername) {
                        errors.emailOrUsername = 'Email or username is required';
                    }

                    if (!values.password) {
                        errors.password = 'Password is required';
                    }
                    return errors;
                }}
                onSubmit={onSubmit}
            >
                {({
                    values,
                    errors,
                    touched,
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    isSubmitting,
                }) => (
                    <div className="container center_div w-25 h-25 mt-5 card mx-auto">
                        <h1 className="card-title text-center mt-3"> Login </h1>
                        <p className="card-title text-center text-secondary">Start using your tracker here</p>
                        <form onSubmit={handleSubmit}>
                            <div className="mb-3">
                                <label htmlFor="emailOrUsername" className="form-label">Email </label>
                                <input type="text" id="emailOrUsername" name="emailOrUsername"
                                    placeholder="example@mail.com"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.emailOrUsername}
                                    required
                                    className={"form-control" + (touched.emailOrUsername && errors.emailOrUsername ? " is-invalid" : "")} />
                                {errors.emailOrUsername && touched.emailOrUsername ? <small className="text-danger">{errors.emailOrUsername}</small> : null}

                            </div>
                            <div className="mb-3">
                                <label htmlFor="password" className="form-label">Password</label>
                                <input type="password" id="password" name="password"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.password}
                                    required
                                    className={"form-control" + (touched.password && errors.password ? " is-invalid" : "")} />
                                {errors.password && touched.password ? <small className="text-danger">{errors.password}</small> : null}
                            </div>
                            <div>
                                <p className="text-danger">{requestError ? requestError : null}</p>
                            </div>
                            <div className="mb-3 d-flex justify-content-between">
                                <button type="submit" className="btn btn-primary" disabled={isSubmitting}>Sing in</button>
                                <Link to={'/'}>Don't have an account still?</Link>
                            </div>
                        </form>
                    </div>
                )}
            </Formik>
        </div>
    )
}