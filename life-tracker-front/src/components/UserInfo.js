import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCoins, faLevelUpAlt } from '@fortawesome/free-solid-svg-icons'

const UserInfo = () => {
    return (
        <div className="card w-1">
            <div className="card-body">
                <div class="container p-4">
                    <div class="row">
                        <div className="col mx-5">
                            <h4 className="mb-3 text-center"> User name</h4>
                            <h6 className="card-subtitle text-muted mb-2"><FontAwesomeIcon icon={faCoins} className="text-warning" /> 10.00 </h6>
                            <div className="d-flex">
                            <h6 className="card-subtitle text-muted mb-2"><FontAwesomeIcon icon={faLevelUpAlt} className="text-info" /> 0</h6>
                            <div class="progress w-75 mx-5">
                                    <div className="progress-bar w-25 bg-info" role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">25%</div>
                            </div>
                            </div>
                        </div>
                        <div className="col justify-content-center align-items-center mx-5">
                            <h4 className="mb-3 text-center">Today stats</h4>
                            <h6 className="card-subtitle mb-2">Number of tasks for today: 0</h6>
                            <h6 className="card-subtitle mb-2">Completed tasks for today: 0</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default UserInfo;