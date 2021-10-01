import registerUser from '../services/AuthService.js'
import { Link } from 'react-router-dom';
import { Formik } from 'formik';

const RegistrationForm = () => {
    return (
        <div>
            <Formik
                initialValues={{ name: '', email: '', password: '', passwordConfirm: '' }}
                validate={values => {
                    const errors = {};
                    if (!values.email) {
                        errors.email = 'Required';
                    } else if (
                        !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
                    ) {
                        errors.email = 'Invalid email address';
                    }
                    return errors;
                }}
                onSubmit={(values, { setSubmitting }) => {
                    registerUser(values)
                        .setTimeout(() => {
                            setSubmitting(false);
                        }, 400);
                }}
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
                    <div class="container center_div w-25 h-25 mt-5 card mx-auto">
                        <h1 class="card-title text-center mt-3"> Register </h1>
                        <p class="card-title text-center text-secondary">Start using your tracker here</p>
                        <form onSubmit={handleSubmit}>
                            <div class="mb-3">
                                <label for="name" class="form-label">Name </label>
                                <input type="text" class="form-control" id="name" name="name" placeholder="Name"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.name}
                                    required />
                            </div>
                            <div class="mb-3">
                                <label for="email" class="form-label">Email </label>
                                <input type="email" class="form-control" id="email" name="email" placeholder="example@mail.com"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.email}
                                    required />
                                {errors.email && touched.email && errors.email}
                            </div>
                            <div class="mb-3">
                                <label for="password" class="form-label">Password</label>
                                <input type="password" class="form-control" id="password" name="password"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.password}
                                    required />
                            </div>
                            <div class="mb-3">
                                <label for="passwordConfirm" class="form-label">Confirm password</label>
                                <input type="password" class="form-control" id="passwordConfirm" name="passwordConfirm"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.passwordConfirm}
                                    required />
                            </div>
                            <div class="mb-3 d-flex justify-content-between">
                                <button type="submit" class="btn btn-primary" disabled={isSubmitting}>Sing up</button>
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