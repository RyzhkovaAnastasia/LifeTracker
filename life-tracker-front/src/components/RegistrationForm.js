import { registerUser } from '../services/AuthService'
import { Link } from 'react-router-dom';
import { Formik } from 'formik';
import { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useHistory } from 'react-router-dom';

export function RegistrationForm (props) {

    const history = useHistory(); 
    
    const [requestError, setError] = useState(null);

    const onSubmit = (values, { setSubmitting }) => {
        registerUser(values)
            .then(()=>{
                setSubmitting(true);
                setError(null);
                props.register(); 
                toast.success("You are succsessfully registered!");
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
                initialValues={{ username: '', email: '', password: '', passwordConfirm: '' }}
                validate={values => {
                    const errors = {};
                    if (!values.username) {
                        errors.username = 'Name is required'
                    }

                    if (!values.email) {
                        errors.email = 'Email is required';
                    }else if(!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)){
                        errors.email = 'Invalid email address';
                    }

                    if (!values.password) {
                        errors.password = 'Password is required';
                    } else if (!values.password.length > 5) {
                        errors.password = 'Password length must be more than 6 characters';
                    }

                    if (!values.passwordConfirm) {
                        errors.passwordConfirm = 'Confirm password is required';
                    } else if (values.passwordConfirm !== values.password) {
                        errors.passwordConfirm = "Confirm password doesn't match password";
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
                        <h1 className="card-title text-center mt-3"> Register </h1>
                        <p className="card-title text-center text-secondary">Start using your tracker here</p>
                        <form onSubmit={handleSubmit}>
                            <div className="mb-3">
                                <label htmlFor="username" className="form-label">Username </label>
                                <input type="text" className="form-control" id="username" name="username" placeholder="username"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.username}
                                    required />
                                {errors.username && touched.username ? <small className="text-danger">{errors.username}</small> : null}
                            </div>
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
                            <div className="mb-3">
                                <label htmlFor="passwordConfirm" className="form-label">Confirm password</label>
                                <input type="password" id="passwordConfirm" name="passwordConfirm"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.passwordConfirm}
                                    required
                                    className={"form-control" + (touched.password && errors.password ? " is-invalid" : "")} />
                                {errors.passwordConfirm && touched.passwordConfirm ? <small className="text-danger">{errors.passwordConfirm}</small> : null}
                            </div>
                            <div>
                                <p className="text-danger">{requestError ? requestError : null}</p>
                            </div>
                            <div className="mb-3 d-flex justify-content-between">
                                <button type="submit" className="btn btn-primary" disabled={isSubmitting}>Sing up</button>
                                <Link to={'/Login'}>I already have an account</Link>
                            </div>
                        </form>
                    </div>
                )}
            </Formik>
        </div>
    )
}
export default RegistrationForm;