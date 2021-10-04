import { loginUser } from '../services/AuthService'
import { Link } from 'react-router-dom';
import { Formik } from 'formik';
import { useState } from 'react';
import { Redirect } from 'react-router';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default function LoginForm(props) {

    const [requestError, setError] = useState(null);

    const onSubmit = (values, { setSubmitting }) => {
        setSubmitting(false);
        setError(null);
        loginUser(values)
            .then(()=>{
                //props.isAuth(true);
                toast.success("You are succsessfully logged in!");
               // setTimeout(()=><Redirect to="/Home" />, 5000);
            })
            .catch(err => {
                setError(err.response.data);
                //props.isAuth(false);
            });
    };

    return (
        <div>
            <ToastContainer />
            <Formik
                initialValues={{ email: '', password: ''}}
                validate={values => {
                    const errors = {};
                    if (!values.email) {
                        errors.email = 'Email is required';
                    }else if(!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)){
                        errors.email = 'Invalid email address';
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
                                <label htmlFor="email" className="form-label">Email </label>
                                <input type="email" id="email" name="email"
                                    placeholder="example@mail.com"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.email}
                                    required
                                    className={"form-control" + (touched.email && errors.email ? " is-invalid" : "")} />
                                {errors.email && touched.email ? <small className="text-danger">{errors.email}</small> : null}

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