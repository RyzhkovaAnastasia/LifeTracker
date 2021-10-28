import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircleCheck, faCoins, faPlus, faMinus, faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'
import Select from 'react-select'
const Dashboard = (user) => {

    const customStyles = {
        container: provided => ({
            ...provided,
            width: 150
        })
    };

    const options = [
        { value: '1', label: 'Tag1' },
        { value: '2', label: 'Tag2' },
        { value: '3', label: 'Tag3' }
    ]
    return (
        <div>
            <div className="m-3 aling-center d-flex justify-content-center">
                <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                <div classname="input-group w-25 mx-3">
                    <input className="form-control" type="text" placeholder="Search"></input>
                    <button className="input-group-text"><FontAwesomeIcon icon={faMagnifyingGlass} /></button>
                </div>
                <Select isMulti options={options}
                    closeMenuOnSelect={false}
                    style={customStyles}
                    menuPlacement="auto"
                    menuPosition="fixed"
                    placeholder={"Tags"} />
            </div>
            <div classname="container mt-5">
                <div classname="row">
                    <div className="col m-1 d-flex justify-content-center">
                        <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                        <h4 className="text-center">Habits</h4>
                    </div>
                    <div className="col m-1 d-flex justify-content-center">
                        <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                        <h4 className="text-center">Dailies</h4>
                    </div>
                    <div className="col m-1 d-flex justify-content-center">
                        <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                        <h4 className="text-center">ToDo's</h4>
                    </div>
                    <div className="col m-1 d-flex justify-content-center">
                        <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                        <h4 className="text-center">Rewards</h4>
                    </div>
                </div>
                <div classname="row">
                    <div className="col bg-light m-1 rounded-3">
                        <div className="bg-white rounded-3 m-2 border">
                            <div className="d-flex justify-content-between m-2">
                                {user.habits != null ? user.habits
                                    .map((habit) => {
                                        return (
                                            <div>
                                                <div className="d-flex justify-content-md-center">
                                                    <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                                                </div>
                                                <div className="justify-content-md-center ">
                                                    <h6 className="card-title m-2"> habit.title </h6>
                                                    <small className="text-muted"> Strike {">>"} habit.strike</small>
                                                </div>
                                                <div className="d-flex justify-content-md-center">
                                                    <button className="btn text-danger"><FontAwesomeIcon icon={faMinus} /></button>
                                                </div>
                                            </div>
                                        )
                                    })
                                    :
                                    <div className="bg-white rounded-3 m-2 border">
                                        <div className="d-flex justify-content-start m-2">
                                            <div className="d-flex justify-content-md-center">
                                                <h6 className="d-flex justify-content-md-center card-title m-2">No habits added</h6>
                                            </div>
                                        </div>
                                    </div>
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col bg-light m-1 rounded-3">
                <div className="bg-white rounded-3 m-2 border">
                    <div className="d-flex justify-content-start m-2">
                        {user.dailies != null ? user.dailies
                            .map(dailies => {
                                return (
                                    <div>
                                        <div className="d-flex justify-content-md-center">
                                            <div classname="input-group-prepend d-flex justify-content-md-center">
                                                <div classname="input-group">
                                                    <button className="btn text-success"><FontAwesomeIcon icon={faCircleCheck} /></button>
                                                </div>
                                            </div>
                                        </div>
                                        <div>
                                            <h6 className="card-title m-2"> Daily name</h6>
                                            <div classname="input-group-prepend mx-2">
                                                <div classname="">
                                                    <input type="checkbox" for="daily" />
                                                    <small className="mx-1">title 1</small>
                                                </div>
                                                <div classname="">
                                                    <input type="checkbox" for="daily" />
                                                    <small className="mx-1">title 2</small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })
                            :
                            <div className="bg-white rounded-3 m-2 border">
                                <div className="d-flex justify-content-start m-2">
                                    <div className="d-flex justify-content-md-center">
                                        <h6 className="card-title m-2 d-flex justify-content-md-center">No dailies added</h6>
                                    </div>
                                </div>
                            </div>
                        }
                    </div>

                </div>
            </div>
            <div className="col bg-light m-1 rounded-3">
                <div className="bg-white rounded-3 m-2 border">
                    <div className="d-flex justify-content-start m-2">
                        {user.toDos != null ? user.toDoes
                            .map(toDos => {
                                return (
                                    <div>
                                        <div className="d-flex justify-content-md-center">
                                            <div classname="input-group-prepend d-flex justify-content-md-center">
                                                <div classname="input-group">
                                                    <button className="btn text-success"><FontAwesomeIcon icon={faCircleCheck} /></button>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="">
                                            <h6 className="card-title m-2"> ToDo name</h6>
                                            <div classname="input-group-prepend mx-2">
                                                <small>20/10/2020</small>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })
                            :
                            <div className="bg-white rounded-3 m-2 border">
                                <div className="d-flex justify-content-start m-2">
                                    <div className="d-flex justify-content-md-center">
                                        <h6 className="card-title m-2 d-flex justify-content-md-center">No todoes added</h6>
                                    </div>
                                </div>
                            </div>
                        }
                    </div>
                </div>
            </div>
            <div className="col bg-light m-1  rounded-3">
                <div className="bg-white rounded-3 m-2 border">
                    <div className="d-flex justify-content-start m-2">
                        {user.rewards != null ? user.rewards
                            .map(rewards => {
                                return (
                                    <div>
                                        <div className="d-flex justify-content-md-center">
                                            <button className="btn text-warning"><FontAwesomeIcon icon={faCoins} /> 10 </button>
                                        </div>
                                        <div className="">
                                            <h6 className="card-title m-2"> Reward name</h6>
                                            <div classname="input-group-prepend mx-2">
                                            </div>
                                        </div>
                                    </div>
                                )
                            })
                            :
                            <div className="bg-white rounded-3 m-2 border">
                                <div className="d-flex justify-content-start m-2">
                                    <div className="d-flex justify-content-md-center">
                                        <h6 className="card-title m-2 d-flex justify-content-md-center">No reward added</h6>
                                    </div>
                                </div>
                            </div>
                        }
                    </div>
                </div>

            </div>
        </div>
    );
}
export default Dashboard;