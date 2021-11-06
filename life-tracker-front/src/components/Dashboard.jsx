import React from 'react';
import Select from 'react-select';
import PropTypes from 'prop-types';
import {
  Container, Row, Col, Card, Badge,
} from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faCircleCheck, faCoins, faPlus, faMinus, faMagnifyingGlass,
} from '@fortawesome/free-solid-svg-icons';

const Dashboard = ({
  habits,
  toDos,
  dailies,
  rewards,
}) => {
  const customStyles = {
    container: (provided) => ({
      ...provided,
      width: 150,
    }),
  };

  const options = [
    { value: '1', label: 'Tag1' },
    { value: '2', label: 'Tag2' },
    { value: '3', label: 'Tag3' },
  ];

  return (
    <div>
      <div className="m-3 aling-center d-flex justify-content-center">
        <div className="d-flex input-group w-25 mx-3">
          <input className="form-control" type="text" placeholder="Search by name" />
          <button className="input-group-text"><FontAwesomeIcon icon={faMagnifyingGlass} /></button>
        </div>
        <div className="d-flex input-group w-25 mx-3">
          <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
          <Select
            isMulti
            options={options}
            closeMenuOnSelect={false}
            style={customStyles}
            menuPlacement="auto"
            menuPosition="fixed"
            placeholder="Tags"
          />
        </div>
      </div>

      <Container>
        <Row>
          <Col md={3} className="d-flex justify-content-center">
            <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
            <h4 className="text-center">Habits</h4>
          </Col>
          <Col md={3} className=" d-flex justify-content-center">
            <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
            <h4 className="text-center">Dailies</h4>
          </Col>
          <Col md={3} className="d-flex justify-content-center">
            <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
            <h4 className="text-center">ToDo&apos;s</h4>
          </Col>
          <Col md={3} className="d-flex justify-content-center">
            <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
            <h4 className="text-center">Rewards</h4>
          </Col>
        </Row>
        <Row>
          <Col md={3} className="bg-light p-3">
            {habits.length ? habits
              .map((habit) => (
                <Card body>
                  <h4 style={{ textAlign: 'center', margin: '0' }}>{habit.title}</h4>
                  <div className="d-flex justify-content-center align-items-center">
                    <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                    <div style={{ margin: '0 auto' }}>
                      Strike:
                      {' '}
                      <Badge bg="secondary">
                        {habit.strike || '0'}
                      </Badge>
                    </div>
                    <button className="btn text-danger"><FontAwesomeIcon icon={faMinus} /></button>
                  </div>
                </Card>
              )) : (
                <h5 className="mt-4">No habits added</h5>
            )}
          </Col>
          <Col md={3} className="bg-light p-3">
            {dailies.length ? dailies
              .map((item) => (
                <Card body>
                  <h4 style={{ textAlign: 'center', margin: '0' }}>{item.title}</h4>
                  <div className="d-flex justify-content-center align-items-center">
                    <button className="btn text-success"><FontAwesomeIcon icon={faPlus} /></button>
                    <div style={{ margin: '0 auto' }}>
                      Strike:
                      {' '}
                      <Badge bg="secondary">
                        {item.strike || '0'}
                      </Badge>
                    </div>
                    <button className="btn text-danger"><FontAwesomeIcon icon={faMinus} /></button>
                  </div>
                </Card>
              )) : (
                <h5 className="mt-4">No dailies added</h5>
            )}
          </Col>
          <div className="col bg-light m-1 rounded-3">
            <div className="bg-white rounded-3 m-2 border">
              <div className="d-flex justify-content-start m-2">
                {toDos.length ? toDos
                  .map((toDoItem) => (
                    <div>
                      <div className="d-flex justify-content-md-center">
                        <div className="input-group-prepend d-flex justify-content-md-center">
                          <div className="input-group">
                            <button className="btn text-success"><FontAwesomeIcon icon={faCircleCheck} /></button>
                          </div>
                        </div>
                      </div>
                      <div className="">
                        <h6 className="card-title m-2">
                          ToDo name
                          {JSON.stringify(toDoItem)}
                        </h6>
                        <div className="input-group-prepend mx-2">
                          <small>20/10/2020</small>
                        </div>
                      </div>
                    </div>
                  ))
                  : (
                    <div className="bg-white rounded-3 m-2 border d-flex">
                      <div className="d-flex justify-content-start m-2">
                        <div className="d-flex justify-content-md-center">
                          <h6 className="card-title m-2 d-flex justify-content-md-center">No todoes added</h6>
                        </div>
                      </div>
                    </div>
                  )}
              </div>
            </div>
          </div>
          <div className="col bg-light m-1  rounded-3">
            <div className="bg-white rounded-3 m-2 border">
              <div className="d-flex justify-content-start m-2">
                {rewards.length ? rewards
                  .map((rewardItem) => (
                    <div>
                      <div className="d-flex justify-content-md-center">
                        <button className="btn text-warning">
                          <FontAwesomeIcon icon={faCoins} />
                          {' '}
                          10
                          {' '}
                        </button>
                      </div>
                      <div className="">
                        <h6 className="card-title m-2">
                          Reward name
                          {JSON.stringify(rewardItem)}
                        </h6>
                        <div className="input-group-prepend mx-2" />
                      </div>
                    </div>
                  ))
                  : (
                    <div className="bg-white rounded-3 m-2 border d-flex">
                      <div className="d-flex justify-content-start m-2">
                        <div className="d-flex justify-content-md-center">
                          <h6 className="card-title m-2 d-flex justify-content-md-center">No reward added</h6>
                        </div>
                      </div>
                    </div>
                  )}
              </div>
            </div>
          </div>
        </Row>
      </Container>
    </div>
  );
};

Dashboard.defaultProps = {
  habits: [{
    title: 'test',
    strike: 1,
    date: new Date().toISOString(),
    difficulty: 1,
    reiteration: 1,
  }],
  toDos: [],
  dailies: [],
  rewards: [],
};

Dashboard.propTypes = {
  habits: PropTypes.arrayOf(
    PropTypes.shape({
      title: PropTypes.string.isRequired,
      strike: PropTypes.number.isRequired,
      date: PropTypes.string.isRequired,
      difficulty: PropTypes.number.isRequired,
      reiteration: PropTypes.number.isRequired,
      isEncouragment: PropTypes.string,
      isPunisment: PropTypes.string,
    }),
  ),
  toDos: PropTypes.arrayOf(
    PropTypes.shape({

    }),
  ),
  dailies: PropTypes.arrayOf(
    PropTypes.shape({

    }),
  ),
  rewards: PropTypes.arrayOf(
    PropTypes.shape({

    }),
  ),
};

export default Dashboard;
