import { Link } from 'react-router-dom';
export default function LoginForm() {
    return (
        <div class="container center_div w-25 h-25 mt-5 card mx-auto">
            <h1 class="card-title text-center mt-3"> Login </h1>
            <p class="card-title text-center text-secondary">Start using your tracker here</p>
            <form>
                <div class="mb-3">
                    <label for="email" class="form-label">Email </label>
                    <input type="email" class="form-control" id="email" placeholder="example@mail.com" required/>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <input type="password" class="form-control" id="password" required/>
                </div>
                <div class="mb-3 d-flex justify-content-between">
                    <button type="submit" class="btn btn-primary">Submit</button>
                    <Link to={'/'} class="">Don't have an account still?</Link>
                </div>
            </form>
        </div>
    );
}