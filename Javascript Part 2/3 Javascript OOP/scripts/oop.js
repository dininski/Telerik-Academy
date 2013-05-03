var vehicles = (function () {
    'use strict';

    // enumeration with the possible afterburner states
    var afterburnerState = Object.freeze({
        'OFF': 0,
        'ON': 1
    });

    // spin direction enumeration
    var SpinDirection = Object.freeze({
        'CLOCKWISE': 0,
        'COUNTER_CLOCKWISE': 1
    });

    // enumeration with the states of the amphibian vehicle
    var AmphibianVehicleMode = Object.freeze({
        'ON_LAND': 0,
        'IN_WATER': 1
    });

    // inheritance function
    Function.prototype.inherits = function (Parent) {
        this.prototype = new Parent();
        this.prototype.constructor = Parent;
    }

    // functionality extending function
    Function.prototype.extends = function (parent) {
        for (var i = 1; i < arguments.length; i++) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }

        return this;
    }

    // default constructer for all the PropulsionUnits
    var PropulsionUnit = function () {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        // this is more of an assertion, becase the PropulsionUnit.getAcceleration() method
        // is private:
        throw new Error('The method PropulsionUnit.getAcceleration() cannot be called, because it is abstract!');
    }

    // the wheel class
    var Wheel = function (radius) {
        if (!radius || radius < 0) {
            throw new Error('Wheel radius, which is larger than 0, must be specified!');
        }

        this.radius = radius;
    }

    Wheel.inherits(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        return parseFloat(2 * Math.PI * this.radius);
    }

    // the propelling nozzle class
    var PropellingNozzle = function (power) {
        if (typeof power === 'undefined') {
            throw new Error('Power must be specified!');
        }

        this.power = power;
        this.afterburnerState = afterburnerState.OFF;
    }

    PropellingNozzle.inherits(PropulsionUnit);

    // the getAcceleration method return 2 times the power
    // if the afterburner is on
    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterburnerState == afterburnerState.ON) {
            return this.power * 2;
        } else {
            return this.power;
        }
    }

    PropellingNozzle.prototype.getAfterburnerState = function () {
        return this.afterburnerState;
    }

    // a method, which turns off and on the afterburner
    PropellingNozzle.prototype.toggleAfterburner = function () {
        if (this.afterburnerState == afterburnerState.ON) {
            this.afterburnerState = afterburnerState.OFF;
        } else {
            this.afterburnerState = afterburnerState.ON;
        }
    }

    // the propeller clsas
    var Propeller = function (numberOfFins, spinDirection) {
        if (!numberOfFins || numberOfFins < 0) {
            throw new Error('A number of fins, which is larger than 0, must be specified!');
        }

        if (typeof spinDirection === 'undefined') {
            throw new Error('A spin direction must be specified!');
        }

        this.numberOfFins = numberOfFins;
        this.spinDirection = spinDirection;
    }

    Propeller.inherits(PropulsionUnit);

    // the getAcceleration method returns the acceleration
    // depending on the spin direction
    Propeller.prototype.getAcceleration = function () {
        if (this.spinDirection == SpinDirection.CLOCKWISE) {
            return this.numberOfFins;
        } else {
            return -this.numberOfFins;
        }
    }

    // changes the spin direction of the propeller
    Propeller.prototype.toggleSpinDirection = function () {
        if (this.spinDirection === SpinDirection.CLOCKWISE) {
            this.spinDirection = SpinDirection.COUNTER_CLOCKWISE;
        } else {
            this.spinDirection = SpinDirection.CLOCKWISE;
        }
    }

    Propeller.prototype.getSpinDirection = function () {
        return this.spinDirection;
    }

    // the vehicles base class
    var Vehicle = function (speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    // a method that changes the speed of the vehicle, depending on 
    // it's acceleration
    Vehicle.prototype.Accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    // a method that returns the current speed of the vehicle
    Vehicle.prototype.getSpeed = function () {
        return this.speed;
    }

    // a method that stops the vehicle
    Vehicle.prototype.stop = function () {
        this.speed = 0;
    }

    // a method that calculates the acceleration of the vehicle
    Vehicle.prototype.getAcceleration = function () {
        var totalAcceleration = 0;
        for (var i = 0; i < this.propulsionUnits.length ; i++) {
            totalAcceleration += this.propulsionUnits[i].getAcceleration();
        }

        return totalAcceleration;
    }

    // the land vehicle class
    var LandVehicle = function (speed, wheels) {
        Vehicle.apply(this, arguments);
    }

    LandVehicle.inherits(Vehicle);

    // the air vehicle class
    var AirVehicle = function (speed, propellingNozzle) {
        Vehicle.apply(this, arguments);
    }

    AirVehicle.inherits(Vehicle);

    // a method for toggling the afterburner on/off
    AirVehicle.prototype.toggleAfterburner = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.propulsionUnits[i].toggleAfterburner();
        }
    }

    // a method, which returns 1 if the afterburner is on and
    // 0 if it is off.
    AirVehicle.prototype.getAfterburnerState = function () {
        return this.propulsionUnits[0].getAfterburnerState;
    }

    // the water vehicle class
    var WaterVehicle = function (speed, propellers) {
        Vehicle.apply(this, arguments);
    }

    WaterVehicle.inherits(Vehicle);

    // a method that changes the propeller direction
    WaterVehicle.prototype.changeSpinDirection = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].toggleSpinDirection();
            }
        }
    }

    // the amphibian class
    var AmphibianVehicle = function (speed, propellers, wheels, mode) {
        var propulsionUnits = new Array();
        for (var i = 0; i < propellers.length; i++) {
            propulsionUnits.push(propellers[i]);
        }

        for (var j = 0; j < wheels.length; j++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    AmphibianVehicle.inherits(Vehicle);
    AmphibianVehicle.extends(WaterVehicle, 'changeSpinDirection');

    // amphibian vehicle overrides the getAcceleration method
    // as it has different behaviour, depending on the vehicle
    // mode
    AmphibianVehicle.prototype.getAcceleration = function () {
        var acceleration = 0;
        if (this.mode === AmphibianVehicleMode.ON_LAND) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    acceleration += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    acceleration += this.propulsionUnits[i].getAcceleration();
                }
            }
        }

        return acceleration;
    }

    // the amphibian vehicle overrides the default accelerate function,
    // because the acceleration varies, depending on the mode
    AmphibianVehicle.prototype.Accelerate = function () {
        this.speed += this.getAcceleration();
    }

    // a method that changes the vehicle's mode and reset it's speed to 0
    // because once the mode is changed the speed should be changed as well
    AmphibianVehicle.prototype.toggleMode = function () {
        this.speed = 0;
        if (this.mode === AmphibianVehicleMode.ON_LAND) {
            this.mode = AmphibianVehicleMode.IN_WATER;
        } else {
            this.mode = AmphibianVehicleMode.ON_LAND;
        }
    }

    // returns the current amphibian mode
    AmphibianVehicle.prototype.getCurrentMode = function () {
        return this.mode;
    }

    return {
        afterburnerState: afterburnerState,
        SpinDirection: SpinDirection,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibianVehicle: AmphibianVehicle,
        AmphibianVehicleMode: AmphibianVehicleMode
    }
})();